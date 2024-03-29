﻿using Kitchen;
using Mono.Cecil;
using System;
using System.IO;
using System.Linq;

namespace Testing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string file = "D:\\Program Files (x86)\\Steam\\steamapps\\common\\PlateUp\\PlateUp\\PlateUp_Data\\Managed\\Kitchen.Common.dll";
            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(file);

            TypeDefinition itemgroupviewtype = assembly.MainModule.GetType("Kitchen.ItemGroupView");
            FieldDefinition componentgroupsfield = itemgroupviewtype.Fields.Where(x => x.Name == "ComponentGroups").FirstOrDefault();
            componentgroupsfield.IsPublic = true;

            TypeDefinition componentgrouptype = itemgroupviewtype.NestedTypes.Where(x => x.Name == "ComponentGroup").FirstOrDefault();
            componentgrouptype.IsNestedPublic = true;


            
            string OutputDir = "D:\\Program Files (x86)\\Steam\\steamapps\\common\\PlateUp\\PlateUp\\PlateUp_Data\\PublicizedAssemblies";

            if (!Directory.Exists(OutputDir))
            {
                Directory.CreateDirectory(OutputDir);
            }
            assembly.Write(Path.Combine(OutputDir, Path.GetFileName(file)));
        }
    }
}
