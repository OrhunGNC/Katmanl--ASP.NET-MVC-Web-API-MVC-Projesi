using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Katmanlı_ASP.NET_MVC_Web_API_MVC_Projesi.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}