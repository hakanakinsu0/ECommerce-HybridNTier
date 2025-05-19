using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        #region SideQuest
        //public string CreatedBy { get; set; }
        //public string DeletedBy { get; set; }
        //public string UpdatedBy { get; set; }
        //public string CreatedIp { get; set; }
        //public string DeletedIp { get; set; }
        //public string UpdatedIp { get; set; }    
        #endregion
        public DataStatus Status { get; set; }
    }
}
