using System.Collections.Generic;

namespace DMS.Presentation
{
	public interface IWorkSpaceViewControl
	{
		void Refresh();
		void GetSelectedEntry();
        void Update();

        List<ColumnTuple> GetColumnsList();

        //List<object> GetFilteredList();

        void ShowFilteredList(string queryColumn, string queryParameter);
    }
}