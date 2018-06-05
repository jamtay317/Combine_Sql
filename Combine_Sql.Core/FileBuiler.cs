using System;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

namespace Combine_Sql.Core
{
    public class FileBuiler:IFileBuiler
    {
        private StringBuilder _stringBuilder;

        public FileBuiler()
        {
            _stringBuilder = new StringBuilder();
        }

        public IFileBuiler Append(string path)
        {
            if(!File.Exists(path)) throw new ArgumentNullException($"This file doesnt exist");
            var newFile = File.ReadAllText(path);

            _stringBuilder.Append(newFile);

            _stringBuilder.Append(Environment.NewLine);
            return this;
        }


        public void Clear()
        {
            _stringBuilder.Clear();
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}