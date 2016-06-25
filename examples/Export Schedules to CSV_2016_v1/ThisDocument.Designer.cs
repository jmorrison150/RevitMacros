//
// Created by SharpDevelop.
// User: michael
// Date: 10/2/2015
// Time: 10:35 AM
// 
// To change this template use Tools | Options | Coding | Edit Standard Headers.
//
 // ERROR: Not supported in C#: OptionDeclaration
namespace ArchSmarter
{

	///
	//[System.CLSCompliantAttribute(false)]
	public sealed partial class ThisDocument : Autodesk.Revit.UI.Macros.DocumentEntryPoint
	{

		public event System.EventHandler Startup;

		public event System.EventHandler Shutdown;

		///
		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
		private void OnStartup()
		{
			Globals.ThisDocument = this;
		}

		///
		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override void FinishInitialization()
		{
			base.FinishInitialization();
			this.OnStartup();
				if (Startup != null) {
					Startup(this, System.EventArgs.Empty);
			}
		}

		///
		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override void OnShutdown()
		{
				if (Shutdown != null) {
					Shutdown(this, System.EventArgs.Empty);
			}
			base.OnShutdown();
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override string PrimaryCookie {
			get { return "ThisDocument"; }
		}
	}
}
namespace ArchSmarter
{

	///
	public sealed partial class Globals
	{

		private static ThisDocument _ThisDocument;

		static internal ThisDocument ThisDocument {
			get { return _ThisDocument; }
			set {
				if ((_ThisDocument == null)) {
					_ThisDocument = value;
				} else {
					throw new System.NotSupportedException();
				}
			}
		}
	}
}
