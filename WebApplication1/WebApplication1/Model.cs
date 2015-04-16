using System;
using System.Collections.Generic;
namespace ConsoleApplication3
{
    public class Model
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public List<Model> Children { get; set; }
      
    }
}