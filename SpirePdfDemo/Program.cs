using Spire.Pdf;
using Spire.Pdf.Fields;
using Spire.Pdf.Widget;
using System;
using System.Drawing;

namespace SpirePdfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {

                string filename = "DemographicForm.pdf";
                // Create a blank page
                PdfDocument doc = new PdfDocument(filename);
                PdfPageBase page = doc.Pages[0];
                doc.AllowCreateForm = true;
                

                // Text Widget Creation 
                // Create an empty text widget with black text.                
                PdfTextBoxField text1 = new PdfTextBoxField(page, "patientName");
                text1.Bounds = new RectangleF(70, 70, 300, 20);
                //text1.BorderWidth = 0.25f;
                //text1.BorderStyle = PdfBorderStyle.Solid;
                text1.Required = true;
                doc.Form.Fields.Add(text1);

                // RadioButton Widget Creation
                // Create a radio button group and add three radio buttons in it.
                PdfRadioButtonListItem item1 = new PdfRadioButtonListItem("minor");
                item1.Bounds = new RectangleF(142, 162, 10, 10);
                //item1.BorderWidth = 0.25f;
                //item1.BorderStyle = PdfBorderStyle.Solid;

                PdfRadioButtonListItem item2 = new PdfRadioButtonListItem("single");
                item2.Bounds = new RectangleF(214, 162, 10, 10);
                //item2.BorderWidth = 0.25f;
                //item2.BorderStyle = PdfBorderStyle.Solid;

                PdfRadioButtonListItem item3 = new PdfRadioButtonListItem("married");
                item3.Bounds = new RectangleF(286, 162, 10, 10);
                //item3.BorderWidth = 0.25f;
                //item3.BorderStyle = PdfBorderStyle.Solid;

                PdfRadioButtonListItem item4 = new PdfRadioButtonListItem("divorced");
                item4.Bounds = new RectangleF(358, 162, 10, 10);
                //item4.BorderWidth = 0.25f;
                //item4.BorderStyle = PdfBorderStyle.Solid;

                PdfRadioButtonListItem item5 = new PdfRadioButtonListItem("widowed");
                item5.Bounds = new RectangleF(430, 162, 10, 10);
                //item5.BorderWidth = 0.25f;
                //item5.BorderStyle = PdfBorderStyle.Solid;

                PdfRadioButtonListItem item6 = new PdfRadioButtonListItem("separated");
                item6.Bounds = new RectangleF(502, 162, 10, 10);
                //item6.BorderWidth = 0.25f;
                //item6.BorderStyle = PdfBorderStyle.Solid;

                PdfRadioButtonListField radio_button_list = new PdfRadioButtonListField(page, "radiobuttons");
                radio_button_list.Items.Add(item1);
                radio_button_list.Items.Add(item2);
                radio_button_list.Items.Add(item3);
                radio_button_list.Items.Add(item4);
                radio_button_list.Items.Add(item5);
                radio_button_list.Items.Add(item6);
                radio_button_list.SelectedIndex = 1;
                doc.Form.Fields.Add(radio_button_list);

                doc.SaveToFile("TestForm.pdf");

            } catch (Spire.Pdf.Exceptions.PdfException e)
            {
                System.Console.WriteLine(e.Message);
            }

            //----------------------------------------------------------------------------------
            // Scenario 2: 
            // Fill-in forms / Modify values of existing fields.
            // Traverse all form fields in the document (and print out their names). 
            // Search for specific fields in the document.
            //----------------------------------------------------------------------------------
            try
            {
                using (PdfDocument doc = new PdfDocument("TestForm.pdf")) {
                    PdfFormWidget formWidget = doc.Form as PdfFormWidget;
                    int index = formWidget.FieldsWidget.FieldNames.IndexOf("patientName");
                    PdfTextBoxFieldWidget text = formWidget.FieldsWidget.List[index] as PdfTextBoxFieldWidget;
                    text.Text = "John Doe";
                    text.Flatten = true;

                    index = formWidget.FieldsWidget.FieldNames.IndexOf("radiobuttons");
                    PdfRadioButtonListFieldWidget radiobuttonscolln = formWidget.FieldsWidget.List[index] as PdfRadioButtonListFieldWidget;                    
                    radiobuttonscolln.SelectedIndex = 2;
                    radiobuttonscolln.Form.IsFlatten = true;

                    doc.SaveAsImage(1);

                    //doc.SaveToFile(@"TestForm_Filled.pdf");
                }
                
            } catch (Spire.Pdf.Exceptions.PdfException e)
            {
                System.Console.WriteLine(e.Message);
            }

            //----------------------------------------------------------------------------------
            // Scenario 3: 
            // Flatten all form fields in a document.
            //----------------------------------------------------------------------------------
            try
            {
                using (PdfDocument doc = new PdfDocument(@"TestForm_Filled.pdf"))
                {
                    doc.Form.IsFlatten = true;
                    doc.SaveToFile(@"TestForm_Flattened.pdf");
                    Console.WriteLine("Done.");
                }
            }
            catch (Spire.Pdf.Exceptions.PdfException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
