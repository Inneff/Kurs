using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class FileModel
    {
        public int FileID { get; set; }
        public int? ProjectID { get; set; }
        public int? TaskID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int? FileSize { get; set; }

        public FileModel() { }
        public FileModel(Files p)
        {
            FileID= p.FileID;
            ProjectID= p.ProjectID;
            TaskID= p.TaskID;
            FileName= p.FileName;
            FilePath= p.FilePath;
            FileSize= p.FileSize;
        }
    }
}
