using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace CSharpEverything
{
    [TestClass]
    public class IQueryableExplained
    {
        [TestMethod]
        public void CanRunCustomQueryableProvider()
        {
            var table = new Source("number");

            //linq statements is just compiler sugar over the linq extension methods
            // the reason that you can do all this stuff with table is because Source implements IQueryable
            var result = from x in table
                         where x > 0
                         select x * x;

            foreach (var x in result)
                Console.WriteLine(x);

        }

        class Source : IQueryable<int>
        {
            readonly string _tableName;
            public List<int> Numbers = new List<int>() {
                1,2,3,4,5,6,7
            };
            public Source(string tableName)
            {
                _tableName = tableName;
            }

            public Type ElementType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Expression Expression
            {
                get
                {
                    return Expression.Constant(this);
                }
            }
            //this will only be called once by the first clause that gets called on the chain
            //in this case the where clause, then it will be passed around to the other things
            public IQueryProvider Provider
            {
                get
                {
                    return new Provider(); 
                }
            }

            public IEnumerator<int> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        class Provider : IQueryProvider
        {
            //this will be called for each clause there is in the chain building up the expression
            public IQueryable CreateQuery(Expression expression)
            {
                return new Query(expression);
            }

            public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            {
                return (IQueryable < TElement > )new Query(expression);
            }

            public object Execute(Expression expression)
            {
                throw new NotImplementedException();
            }

            public TResult Execute<TResult>(Expression expression)
            {
                throw new NotImplementedException();
            }

        }
        class Query : IQueryable<int>
        {
            readonly Expression _expression;
            public Query(Expression expression)
            {
                _expression = expression;
            }
            public Type ElementType
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public Expression Expression
            {
                get
                {
                    return _expression;
                }
            }

            public IQueryProvider Provider
            {
                get
                {
                    return new Provider();
                }
            }


            public IEnumerator<int> GetEnumerator()
            {
                //at this point the query is done and its time to use it probably because a for loop has executed
                //the expression tree will have the data structure of the entire linq query 
                //its up to this thing to parse the tree and do whatever it needs to do to get the information
                //in order to actually do anything with hit you need to create a class that inherits from expression visitor

                var visitor = new MySourceExpressionVisitor();
                visitor.Visit(_expression);
                //the expression visitor would now be responsible for returning whatever data 
                //so it might expose an Ienumerator itself? and you just loop through it yielding the results
                //OR the expression visitor would just make a SQL statement for example and this Query class will use it to call the database and 
                //  return the data itself
                yield return 1;
                yield return 5;
                yield return 4;
                yield return 2;
                yield return 3;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        //http://pelebyte.net/blog/2011/05/13/doing-simple-things-with-expressionvisitor/
        //http://blogs.msdn.com/b/mattwar/archive/2007/07/31/linq-building-an-iqueryable-provider-part-ii.aspx
        //in order to do anything you just override the methods that handle whatever part of an expression you care about
        class MySourceExpressionVisitor : ExpressionVisitor
        {
           
            //var result = from x in table
            //             where x > 0
            //             select x * x;

            //this could be made simple by just assuming that the pattern will always be the same
            //there will be one main select and then a where clause
            //store a reference to each and do something accordingly


            public StringBuilder sb = new StringBuilder();
            Source currentSource = null;
            protected override Expression VisitParameter(ParameterExpression node)
            {
                sb.AppendLine(node.Name);
                return node;
            }
            //why is there a null node
            //why are the right side of the lambdas ( the > and * ) visited before the left side parameters x
            public override Expression Visit(Expression node)
            {
                return base.Visit(node);
            }
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                //this is the representation of the lambda that is used for whatetver method was just called Where or Select
                //it is called fifth because it is directly under the where clause to the right
                sb.AppendLine("Lambda");
                return base.VisitLambda<T>(node);
            }
            protected override Expression VisitUnary(UnaryExpression node)
            {
                //this is called forth i have no idea what this is, it is like wrapping a lambda expression having to do with closure or something
                //yikes - what the hell
                //http://stackoverflow.com/questions/3716492/what-does-expression-quote-do-that-expression-constant-can-t-already-do
                if (node.NodeType == ExpressionType.Quote)
                {
                    sb.AppendLine("Quote");
                }
                return base.VisitUnary(node);
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (node != null)
                {
                    //this is the second thing found because it is directly beneath the select epresssion on the left
                    if (node.Method.Name == "Where")
                    {
                        sb.AppendLine("Where");
                    }
                    //this is the first thing found because the top node of this whol expression tree is the select statement
                    //on the left is the where clause which combines the datasource and what to take from the datasource
                    // on the right is there select's clause which says what should atually be returned which could have nothing to do with the actual data
                    //you could retrieve some records and then just return a list of 1's for some reason
                    if (node.Method.Name == "Select")
                    {
                        sb.AppendLine("Select");
                    }
                }
                return base.VisitMethodCall(node);
            }
            protected override Expression VisitConstant(ConstantExpression node)
            {
                //the thing that you are querying data from is considered a constant
                var s = node.Value as Source;
                if (s != null)
                {
                    //this is the third thing found as it is directly under the where clause and to the left
                    sb.AppendLine("take from the source");
                    currentSource = s;
                }else
                    sb.AppendLine(node.Value.ToString());

                return node;
            }
            protected override Expression VisitBinary(BinaryExpression node)
            {
                sb.Append("(");

                this.Visit(node.Left);

                switch (node.NodeType)
                {
                    case ExpressionType.Add:
                        sb.Append(" + ");
                        break;

                    case ExpressionType.Divide:
                        sb.Append(" / ");
                        break;
                    case ExpressionType.Subtract:
                        sb.Append(" + ");
                        break;

                    case ExpressionType.Multiply:
                        sb.Append(" * ");
                        break;

                    case ExpressionType.GreaterThan:
                        sb.Append(" > ");
                        break;
                    case ExpressionType.LessThan:
                        sb.Append(" < ");
                        break;

                }

                this.Visit(node.Right);

                sb.Append(")");

                return node;
            }
        }
    }


}
