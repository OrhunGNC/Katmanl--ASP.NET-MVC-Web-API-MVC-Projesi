using System;
using System.Reflection;

namespace Katmanlı_ASP.NET_MVC_Web_API_MVC_Projesi.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}