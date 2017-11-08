using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class ObjectEventArgs : EventArgs
	{
		public object Object {
			get;
			set;
		}

		public ObjectEventArgs (object Obj, bool isClickEvent = false)
		{
			this.Object = Obj;
			IsClickEvent = isClickEvent;
		}

		public bool IsClickEvent { get; set; }
	}

	public class SelectedObjectEventArgs : EventArgs
	{
		public object CollectionObjects {
			get;
			set;
		}

		public object SelectedObject {
			get;
			set;
		}

		public SelectedObjectEventArgs (object selectedObject, object collectionObjects)
		{
			this.SelectedObject = selectedObject;
			this.CollectionObjects = collectionObjects;
		}

		public SelectedObjectEventArgs()
		{
		}
	}

	public class SortingObjectEventArgs : EventArgs
	{

		public List<string> SortKeys {
			get;
			set;
		}

		public List<int> SortDirections {
			get;
			set;
		}
	}

	public class StringObjectEventArgs:EventArgs
	{
		public string Value {
			get;
			set;
		}

		public StringObjectEventArgs (string value)
		{
			Value = value;
		}
	}

	public class AlertViewObjectEventArgs:StringObjectEventArgs
	{
		public string Title {
			get;
			set;
		}

		public AlertViewObjectEventArgs (string value, string title) : base (value)
		{
			Title = title;
		}
	}
}

