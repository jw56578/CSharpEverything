using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;


namespace Data.Parse
{
    public class Parse
    {
        static Parse()
        {
            ParseClient.Initialize("3LTfRppRmRFEM6SpRWUx9b7PvSstlFx9YLKSqpAY", "cJnlR38ydLol1Y5J6p5SQRYX0xBldL6N5K5pgfHf");
        }
        public Parse()
        {

          

        }
        public async Task<IEnumerable<ParseObject>> Find(string entityName)
        {
            var query = ParseObject.GetQuery(entityName);
            //.WhereEqualTo("playerName", "Dan Stemkoski");
            return await query.FindAsync();
        }

    }
}
