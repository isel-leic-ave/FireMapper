using System;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace FireSource
{
    public record FireDataSource(
        string ProjectId, 
        string Collection, 
        string Key,
        string CredentialsPath) : IDataSource
    {
        readonly FirestoreDb db = Init(ProjectId, CredentialsPath);

        static FirestoreDb Init(string projectId, string credentialsPath) {
            Environment.SetEnvironmentVariable(
                "GOOGLE_APPLICATION_CREDENTIALS",
                credentialsPath
            );
            return FirestoreDb.Create(projectId);
        }

        public void Add(Dictionary<string, object> obj)
        {
            _ = db.Collection(Collection).AddAsync(obj).Result;
        }

        public void Delete(object KeyValue)
        {
            QuerySnapshot result = db.Collection(Collection).WhereEqualTo(Key, KeyValue).GetSnapshotAsync().Result;
            foreach(var doc in result.Documents) {
                WriteResult res = doc.Reference.DeleteAsync().Result; // Wait for Completion
            }
        }

        public IEnumerable<Dictionary<string, object>> GetAll()
        {
            QuerySnapshot query = db.Collection(Collection).GetSnapshotAsync().Result;
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            foreach(DocumentSnapshot doc in query) {
                lst.Add(doc.ToDictionary());
            }
            return lst;
        }

        public Dictionary<string, object> GetById(object KeyValue)
        {
            DocumentSnapshot doc = GetDoc(KeyValue);
            return doc?.ToDictionary();
        }

        public DocumentSnapshot GetDoc(object KeyValue)
        {
            IEnumerator<DocumentSnapshot> iter = db
                .Collection(Collection)
                .WhereEqualTo(Key, KeyValue)
                .GetSnapshotAsync()
                .Result
                .GetEnumerator();
            return iter.MoveNext() ? iter.Current : null;
        }

        public void Update(Dictionary<string, object> obj)
        {
            DocumentSnapshot doc = GetDoc(obj[Key]);
            if(doc == null) throw new ArgumentException("No document in database for given Key = " + obj[Key]);
            WriteResult result = doc.Reference.UpdateAsync(obj).Result;
        }
    }
}
