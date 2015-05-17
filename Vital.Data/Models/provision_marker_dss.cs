using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class provision_marker_dss
    {
        public int object_id { get; set; }
        public int owner_scope_local_id { get; set; }
        public Nullable<int> provision_scope_local_id { get; set; }
        public long provision_timestamp { get; set; }
        public int provision_local_peer_key { get; set; }
        public Nullable<int> provision_scope_peer_key { get; set; }
        public Nullable<long> provision_scope_peer_timestamp { get; set; }
        public Nullable<System.DateTime> provision_datetime { get; set; }
        public Nullable<int> state { get; set; }
        public byte[] version { get; set; }
    }
}