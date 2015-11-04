using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gas_test2.BLL
{
    class DocumentManager//这个类就是将文件加入到队列以及从队列中读取文件
    {
        /// <summary>
        /// 读取文档操作即文档管理
        /// </summary>

        private readonly Queue<Document> documentQueue = new Queue<Document>();//实例一个队列
        public void AddDocument(Document doc)//将Document类型的文件添加到队列中
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public Document GetDocument()  //读取队列中的文件
        {
            Document doc = null;
            lock (this)
            {
                doc = documentQueue.Dequeue();//doc = documentQueue.Peek();
            }
            return doc;
        }
        public bool IsDoctumentAvailable   //判断队列知否为空。
        {
            get { return documentQueue.Count > 0; }
        }

    }
}
