namespace Spike.Web.Models
{
    using System.Collections.Generic;
    
    public class ContentDeliveryModel
    {
        public string PageName { get; set; }

        public string SectionTitel { get; set; }

        public List<Method> Methods { get; set; }
    }
}