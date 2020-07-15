using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Web.UI.Design;
using Microsoft.Web.UI;

namespace InsGrid {
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:PopCalendar runat=server></{0}:PopCalendar>")]
	[Designer("InsGrid.DropClndrDesigner") ]
	public class PopCalendar : WebControl, INamingContainer {
		TextBox		tbInput		= new TextBox();
		Calendar	clCanlendar = new Calendar();
		WebControl	pnlClndr	= new WebControl(HtmlTextWriterTag.Div);

		[Bindable(true, BindingDirection.TwoWay)]
		[Browsable(true)						]
		[Category("Appearance")					]
		[DefaultValue("")						]
		[Localizable(true)						]
		public string Text {
			get {	return tbInput.Text;		}
			set {	tbInput.Text = value;		}
		}

		public bool Hidden {
			get { object o = ViewState["hidden"]; return o == null ? true : (bool)o;  }
			set { ViewState["hidden"] = value;	}
		}
	

		protected void ShowCalendar(bool init) {
			pnlClndr.Visible = true;
			DateTime dt;
			if (DateTime.TryParse(Text, out dt)) {
				clCanlendar.SelectedDate = dt;
				if (init)
					clCanlendar.VisibleDate = dt;
			}
		}
		protected override void CreateChildControls() {
			base.CreateChildControls();
			ScriptManager sm = ScriptManager.GetCurrent(Page);
			bool AsyncPostback = (sm != null);
			WebControl divPanel = new WebControl(HtmlTextWriterTag.Div);
			if (AsyncPostback) {
				UpdatePanel pnl = new UpdatePanel();
				pnl.ID = "UpdPnl" + this.ID;
				Controls.Add(pnl);
				pnl.ContentTemplateContainer.Controls.Add(divPanel);
			}
			else
				Controls.Add(divPanel);
			tbInput.MaxLength = 10;
			tbInput.Attributes["size"] = "10";
			divPanel.Controls.Add(tbInput);

			Button btn = new Button();
			btn.Text = "...";
			btn.Click += delegate(Object sender, EventArgs e) {
				if (Hidden)
					ShowCalendar(true);
			};
			divPanel.Controls.Add(btn);

			divPanel.Controls.Add(pnlClndr);
			pnlClndr.BackColor = System.Drawing.Color.White;
			pnlClndr.Visible = false;
			pnlClndr.Style["ZORDER"] = "100";

			clCanlendar.VisibleMonthChanged += delegate(Object sender, MonthChangedEventArgs e) {
				ShowCalendar(false);
			};
			clCanlendar.SelectionChanged += delegate(Object sender, EventArgs e) {
				Text = clCanlendar.SelectedDate.ToShortDateString();
			};
			pnlClndr.Controls.Add(clCanlendar);
			pnlClndr.ID = this.UniqueID + "_popup";

			string jsMove = @"
				function popupClndr_movePopup(pn) {
					var elem = document.getElementById(pn);
					if (!elem) 
						return;
					elem.style.zorder = 100;
					elem.parentNode.style.position = 'relative';
					elem.style.position = 'absolute';
					elem.style.visibility = 'visible';
					elem.style.top = elem.parentNode.offsetHeight;
					elem.style.left = 0;
				}
				function ajaxClndr_movePopup(sender, args) {
					var updatedPanels = args.get_panelsUpdated();
					alert(updatedPanels);
					for (i=0; i < updatedPanels.length; i++)  {
						//popupClndr_movePopup(updatedPanels[i]);
						alert(updatedPanels[i].innerHTML);
				}			
			";
			string ajaxMove = @"
				Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(ajaxClndr_movePopup);
			";

			if (AsyncPostback && !Page.ClientScript.IsClientScriptBlockRegistered("popupClndr"))
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popupClndr", jsMove, true);
			if (!Page.ClientScript.IsStartupScriptRegistered("ajaxClndr"))
				Page.ClientScript.RegisterStartupScript(this.GetType(), "ajaxClndr", ajaxMove, true);
			if (!Page.ClientScript.IsStartupScriptRegistered("popupClndr_" + this.UniqueID))
				Page.ClientScript.RegisterStartupScript(this.GetType(), "popupClndr_" + this.UniqueID,
					"popupClndr_movePopup('" + pnlClndr.ClientID + "');", true);
		}

		protected override void OnPreRender(EventArgs e) {
			Page.Trace.Warn(string.Format("Prerender  {0} {1}", this.UniqueID, ViewState["hidden"]));
			Hidden = !pnlClndr.Visible;
			base.OnPreRender(e);
		}

		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle DayStyle { get { return clCanlendar.DayStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
        public TableItemStyle OtherMonthDayStyle { get { return clCanlendar.OtherMonthDayStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
        public TableItemStyle SelectedDayStyle { get { return clCanlendar.SelectedDayStyle; } }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle TitleStyle{ get { return clCanlendar.TitleStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle NextPrevStyle{ get { return clCanlendar.NextPrevStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle SelectorStyle{ get { return clCanlendar.SelectorStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle TodayDayStyle{ get { return clCanlendar.TodayDayStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle WeekendDayStyle{ get { return clCanlendar.WeekendDayStyle;	} }
		[Category("Styles"), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle DayHeaderStyle{ get { return clCanlendar.DayHeaderStyle;	} }

	}

	public class DropClndrDesigner : ControlDesigner {
		public override string GetDesignTimeHtml() {
			return "<input type='text' size='10' value='1/1/2001'/><button>...</button>";
		}

	}
}
