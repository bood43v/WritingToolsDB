using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WritingToolsDB
{
    internal class SqlData
    {
            public SqlData()
            {
                sqlConnection = null;
                sqlBuilder = null;
                sqlDataAdapter = null;
                dataset = null;
        
            }

            public SqlConnection sqlConnection;

            public SqlCommandBuilder sqlBuilder;

            public SqlDataAdapter sqlDataAdapter;

            public DataSet dataset;


    }
}
