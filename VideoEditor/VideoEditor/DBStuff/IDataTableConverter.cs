using System;
using System.Collections.Generic;
using System.Data;

namespace VideoEditor
{
   public interface IDataTableConverter<T>
   {
      DataTable GetDataTable(List<T> items);
   }
}
