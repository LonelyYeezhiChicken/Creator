using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creator.Model.Template.CSharp
{
    public class CsService
    {

        public string NameSpace { get; private set; }
        public string Name { get; private set; }


        public CsService(string nameSpace, string name)
        {
            NameSpace = string.IsNullOrEmpty(nameSpace) ? throw new AggregateException(nameof(nameSpace)) : nameSpace;
            Name = string.IsNullOrEmpty(name) ? throw new AggregateException(nameof(name)) : name;
        }


        /// <summary>
        /// interface 區塊
        /// </summary>
        private string InterFaceBlock
        {
            get
            {
                return $@" internal interface I{Name}
    {{
       
    }}";
            }
        }

        /// <summary>
        /// 實作區塊
        /// </summary>
        private string ImpBlock
        {
            get
            {
                return $@"
internal class {Name}Service : I{Name}
    {{
       
    }}";
            }
        }

        /// <summary>
        /// NameSpace 區塊
        /// </summary>
        private string NameSpaceBlocek
        {
            get
            {
                return $@"namespace {NameSpace}
{{
{InterFaceBlock}

{ImpBlock}
}}";
            }
        }

        public string Get()
        {
            return NameSpaceBlocek;
        }

    }
}
