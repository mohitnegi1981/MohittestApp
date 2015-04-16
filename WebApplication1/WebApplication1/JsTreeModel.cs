using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;


namespace WebApplication1
{
    
    public class JsTreeModel
    {

        public string data;
        public string title;
        public JsTreeAttribute attr;
       
        public List<JsTreeModel> children;
        public JsTreeModel()
        {
            children = new List<JsTreeModel>();
        }
    }

    
    public class JsTreeAttribute
    {
        public int id;
        public string title;
        public string name;
        public string type;
        public string path;
    }

    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "folder")]
        public List<FolderItem> Folder { get; set; }
    }

    public class Model
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public List<Model> Children { get; set; }

    }


    public class FileItem
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { set; get; }

        [XmlIgnore]
        public string[] Parents { set; get; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "parentId")]
        public string ParentId { get; set; }

        [XmlAttribute(AttributeName = "fullPath")]
        public string FullPath { get; set; }

        [XmlAttribute(AttributeName = "path")]
        public string Path { get; set; }
    }

    public class FolderItem
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { set; get; }

        [XmlElement(ElementName = "folder")]
        public List<FolderItem> SubFolder { get; set; }

        [XmlElement(ElementName = "file")]
        public List<FileItem> File { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "parentId")]
        public string ParentId { get; set; }

        [XmlIgnore]
        public string SingleFileName { get; set; }

        [XmlAttribute(AttributeName = "fullPath")]
        public string FullPath { get; set; }

        [XmlAttribute(AttributeName = "path")]
        public string Path { get; set; }

    }
}