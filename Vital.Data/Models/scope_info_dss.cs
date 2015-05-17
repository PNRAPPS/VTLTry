using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class scope_info_dss
    {
        public int scope_local_id { get; set; }
        public System.Guid scope_id { get; set; }
        public string sync_scope_name { get; set; }
        public byte[] scope_sync_knowledge { get; set; }
        public byte[] scope_tombstone_cleanup_knowledge { get; set; }
        public byte[] scope_timestamp { get; set; }
        public Nullable<System.Guid> scope_config_id { get; set; }
        public int scope_restore_count { get; set; }
        public string scope_user_comment { get; set; }
    }
}
