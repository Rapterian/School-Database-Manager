using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_PRG282.LogicLayer
{
    internal class Module
    {
        string moduleCode, moduleName, moduleDescription, links;

        public Module(string moduleCode, string moduleName, string moduleDescription, string links)
        {
            this.ModuleCode = moduleCode;
            this.ModuleName = moduleName;
            this.ModuleDescription = moduleDescription;
            this.Links = links;
        }

        public Module()
        {

        }

        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
        public string ModuleDescription { get => moduleDescription; set => moduleDescription = value; }
        public string Links { get => links; set => links = value; }
    }
}
