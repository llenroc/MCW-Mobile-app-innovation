﻿using System;
using Xamarin.Forms;

namespace ContosoBaggage.Controls
{
	public class DataTemplatePresenter : ContentView
	{
		public static readonly BindableProperty ItemTemplateProperty = 
			BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(ContentPresenter), 
			                        null, propertyChanged: OnItemTemplateChanged);

		private static void OnItemTemplateChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
            var cp = (DataTemplatePresenter)bindable;

			var template = cp.ItemTemplate;
			if (template != null)
			{
				var content = (View)template.CreateContent();
				cp.Content = content;
			}
			else
			{
				cp.Content = null;
			}
		}

		public DataTemplate ItemTemplate
		{
			get
			{
				return (DataTemplate)GetValue(ItemTemplateProperty);
			}
			set
			{
				SetValue(ItemTemplateProperty, value);
			}
		}
	}
}
