using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMS.Presentation
{
	/// <summary>
	/// Interaction logic for WorkSpaceViewControl
	/// </summary>
	public abstract class WorkSpaceViewControl : UserControl
	{
		public WorkSpaceViewControl()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			//
		}

		#region Inheritance Methods (for sub classes
		public virtual void GetSelectedEntry()
		{

		}

		public virtual void Refresh()
		{

		}

		public static explicit operator WorkSpaceViewControl(TabItem v)
		{
			if (v.Content is WorkSpaceViewControl)
			{
				return v.Content as WorkSpaceViewControl;
			}
			else
			{
				throw new InvalidCastException();
			}
		}



		#endregion
	}
}
