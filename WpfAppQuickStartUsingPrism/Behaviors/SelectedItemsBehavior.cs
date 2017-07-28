using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prism.Commands;

namespace WpfAppQuickStartUsingPrism.Behaviors
{
	public class SelectedItemsBehavior
	{
		public static readonly DependencyProperty SelectedItemsChangedHandlerProperty =
			DependencyProperty.RegisterAttached("SelectedItemsChangedHandler",
				typeof(DelegateCommand<IList>),
			typeof(SelectedItemsBehavior), new FrameworkPropertyMetadata(OnSelectedItemsChangedHandlerChanged));



		public static DelegateCommand<IList> GetSelectedItemsChangedHandler(DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			return element.GetValue(SelectedItemsChangedHandlerProperty) as DelegateCommand<IList>;
		}

		public static void SetSelectedItemsChangedHandler(DependencyObject element, DelegateCommand<IList> value)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			element.SetValue(SelectedItemsChangedHandlerProperty, value);
		}


		private static void OnSelectedItemsChangedHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;

			if (e.OldValue == null && e.NewValue != null)
			{
				dataGrid.SelectionChanged += ItemsControl_SelectionChanged;
			}

			if (e.OldValue != null && e.NewValue == null)
			{
				dataGrid.SelectionChanged -= ItemsControl_SelectionChanged;
			}

		}



		public static void ItemsControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)sender;

			DelegateCommand<IList> itemsChangedHandler = GetSelectedItemsChangedHandler(dataGrid);

			itemsChangedHandler.Execute(dataGrid.SelectedItems);

		}

	}
}
