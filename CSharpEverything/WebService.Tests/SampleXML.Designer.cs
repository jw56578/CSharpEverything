﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SampleXML {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SampleXML() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebService.Tests.SampleXML", typeof(SampleXML).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;!--Sample XML file generated by XMLSpy v2012 rel. 2 sp1 (http://www.altova.com)--&gt;
        ///&lt;vls:ExtGetVehicleInventory xsi:schemaLocation=&quot;urn:com.gm:vls ExtGetVehicleInventory.xsd&quot; xmlns:oagis=&quot;http://www.openapplications.org/oagis/9&quot; xmlns:star=&quot;http://www.starstandard.org/STAR/5&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:vls=&quot;urn:com.gm:vls&quot;&gt;
        ///	&lt;vls:ExtApplicationArea&gt;
        ///		&lt;vls:ExtSender&gt;
        ///			&lt;star:ComponentID&gt;Locate Module&lt;/star:ComponentID&gt;
        ///			&lt;star:T [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetVehicleInventoryWithAllCriteria {
            get {
                return ResourceManager.GetString("GetVehicleInventoryWithAllCriteria", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;vls:ExtShowVehicleInventory xsi:schemaLocation=&quot;urn:com.gm:vls ExtShowVehicleInventory.xsd&quot; xmlns:star=&quot;http://www.starstandard.org/STAR/5&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:udt=&quot;http://www.openapplications.org/oagis/9/unqualifieddatatypes/1.1&quot; xmlns:vls=&quot;urn:com.gm:vls&quot;&gt;
        ///	&lt;vls:ExtApplicationArea&gt;
        ///		&lt;star:Sender&gt;
        ///			&lt;star:ComponentID&gt;VLS&lt;/star:ComponentID&gt;
        ///			&lt;star:TaskID&gt;Vehicle Locator Service&lt;/star:TaskID&gt;
        ///			&lt;star:CreatorNameCode&gt;VL [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InventorySearchResponse {
            get {
                return ResourceManager.GetString("InventorySearchResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;
        ///&lt;Payload xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///  &lt;content xmlns=&quot;http://www.starstandards.org/webservices/2005/10/transport&quot;&gt;
        ///&lt;vls:ExtGetVehicleInventory xsi:schemaLocation=&quot;urn:com.gm:vls ExtGetVehicleInventory.xsd&quot; xmlns:oagis=&quot;http://www.openapplications.org/oagis/9&quot; xmlns:star=&quot;http://www.starstandard.org/STAR/5&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:vls=&quot;urn:com.gm:vls&quot;&gt;
        ///	&lt;vls [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SerializedPayloadTemplate {
            get {
                return ResourceManager.GetString("SerializedPayloadTemplate", resourceCulture);
            }
        }
    }
}
