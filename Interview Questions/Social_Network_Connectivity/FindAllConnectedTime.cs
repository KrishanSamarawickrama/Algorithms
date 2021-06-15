using System.IO;

namespace Social_Network_Connectivity
{
    public class FindAllConnectedTime
    {
        private int[] Members;
        private int[] Size;

        public FindAllConnectedTime(int memberCount)
        {
            InitializeMembers(memberCount);
        }

        private void InitializeMembers(int count)
        {
            Members = new int[count];
            Size = new int[count];
            for (int i = 0; i < count; i++)
            {
                Members[i] = i;
                Size[i] = 1;
            }
        }

        public string ReadLog(string lofFilePath)
        {
            var logEntrees = File.ReadLines(lofFilePath);

            foreach (string log in logEntrees)
            {
                var records = log.Split(',');
                var timestamp = records[0];
                var member1Id = int.Parse(records[1]);
                var member2Id = int.Parse(records[2]);

                if (!IsMemberConnected(member1Id, member2Id))
                {
                    UnionMember(member1Id, member2Id);
                }

                if (Size[Root(member1Id)] == Members.Length) return timestamp;
            }

            return "Not found.";
        }

        private int Root(int memberId)
        {
            while (memberId != Members[memberId])
            {
                Members[memberId] = Members[Members[memberId]];
                memberId = Members[memberId];
            }

            return memberId;
        }

        public bool IsMemberConnected(int member1Id, int member2Id)
        {
            return Root(member1Id) == Root(member2Id);
        }

        public void UnionMember(int member1Id, int member2Id)
        {
            int m1_root_mem = Root(member1Id);
            int m2_root_mem = Root(member2Id);

            if (m1_root_mem == m2_root_mem) return;

            if(Size[m1_root_mem] < Size[m2_root_mem])
            {
                Members[m1_root_mem] = m2_root_mem;
                Size[m2_root_mem] += Size[m1_root_mem];
            }
            else
            {
                Members[m2_root_mem] = m1_root_mem;
                Size[m1_root_mem] += Size[m2_root_mem];
            }
        }
    }
}