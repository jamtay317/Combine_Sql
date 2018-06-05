﻿namespace Combine_Sql.Core
{
    public interface ISqlRunner
    {
        void Run(string sql, string fileName);

        void RunAll(string directoryName);
    }
}