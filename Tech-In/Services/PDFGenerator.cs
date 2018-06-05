using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tech_In.Models.ViewModels.ProfileViewModels;

namespace Tech_In.Services
{
    public class PDFGenerator
    {
        #region Declerations
        int _totalColumn = 6;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfPTable = new PdfPTable(6);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        ProfileViewModal _user;
        //University _university = new University();
        #endregion
        public PDFGenerator(ProfileViewModal pVM)
        {
            _user = pVM;
        }

        public byte[] PrepareReport()
        {
            //_university = university;

            #region
            _document = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
            
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 20f, 25f, 25f, 25f, 25f, 25f });
            #endregion

            this.ReportHeader();
            this.HorizontalLine();
            this.Objective();
            foreach(ExperienceVM vm in _user.ExpVMList)
                this.Experience(vm);

            foreach(EducationVM vm in _user.EduVMList)
                this.Education(vm);

            this.Projects();
            this.Achievements();
            _pdfPTable.HeaderRows = 2;
            _document.Add(_pdfPTable);
            _document.Close();
            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            //Name
            _fontStyle = FontFactory.GetFont("Calibri", 16f, 1);
            _pdfPCell = new PdfPCell(new Phrase(_user.UserPersonalVM.FullName, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            //Address Row

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 1);
            _fontStyle.SetColor(25, 111, 61);
            _pdfPCell = new PdfPCell(new Phrase("Address: ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("House 1, Sector 1, Khan Akbar Town, New Shakrial, Islamabad, Pakistan ", _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);


            _fontStyle = FontFactory.GetFont("Calibri", 8f, 0);
            //_pdfPCell = new PdfPCell(new Phrase("[Add Image Here]", _fontStyle));
            _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            //Email Row
            _fontStyle = FontFactory.GetFont("Calibri", 10f, 1);
            _fontStyle.SetColor(25, 111, 61);
            _pdfPCell = new PdfPCell(new Phrase("E-mail: ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_user.UserPersonalVM.Email, _fontStyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);


            _fontStyle = FontFactory.GetFont("Calibri", 10f, 1);
            _fontStyle.SetColor(25, 111, 61);
            _pdfPCell = new PdfPCell(new Phrase("Mobile #: ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_user.UserPersonalVM.PhoneNo, _fontStyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Arial", 10f, 0);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();



        }

        private void Objective()
        {
            //New Line
            _fontStyle = FontFactory.GetFont("Arial", 10f, 0);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 11f, 1);
            _fontStyle.SetColor(33, 97, 140);
            _pdfPCell = new PdfPCell(new Phrase("Objective", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
            if(_user.UserPersonalVM.Summary!=null)
                _pdfPCell = new PdfPCell(new Phrase(_user.UserPersonalVM.Summary, _fontStyle));
            else
                _pdfPCell = new PdfPCell(new Phrase("No Summary added yet!", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();
        }

        private void Education(EducationVM vm)
        {
            _fontStyle = FontFactory.GetFont("Calibri", 11f, 1);
            _fontStyle.SetColor(33, 97, 140);
            _pdfPCell = new PdfPCell(new Phrase("Education", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 1);
            _fontStyle.SetColor(25, 111, 61);
            _pdfPCell = new PdfPCell(new Phrase(vm.SchoolName, _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
            if(vm.CurrentStatusCheck)
                _pdfPCell = new PdfPCell(new Phrase(vm.StartDate.ToString("dd MMM yyyy") + " - Current", _fontStyle));
            else
                _pdfPCell = new PdfPCell(new Phrase(vm.StartDate.ToString("dd MMM yyyy")+ " - "+vm.EndDate.ToString("dd MMM yyyy"), _fontStyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
            _pdfPCell = new PdfPCell(new Phrase(vm.Title, _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
            _pdfPCell = new PdfPCell(new Phrase("3.59/4.00", _fontStyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();
            NewLine();
        }

        private void Experience(ExperienceVM vm)
        {
            NewLine();

            _fontStyle = FontFactory.GetFont("Calibri", 11f, 1);
            _fontStyle.SetColor(33, 97, 140);
            _pdfPCell = new PdfPCell(new Phrase("Experience", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Calibri", 10f, 1);
            _fontStyle.SetColor(25, 111, 61);
            _pdfPCell = new PdfPCell(new Phrase(vm.Title, _fontStyle));
            _pdfPCell.Colspan = 4;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
            if (vm.CurrentWorkCheck)
                _pdfPCell = new PdfPCell(new Phrase(vm.StartDate.ToString("dd MMM yyyy") + " - Current", _fontStyle));
            else
                _pdfPCell = new PdfPCell(new Phrase(vm.StartDate.ToString("dd MMM yyyy") + " - " + vm.EndDate.ToString("dd MMM yyyy"), _fontStyle));

            _pdfPCell.Colspan = 2;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
            _pdfPCell = new PdfPCell(new Phrase(vm.Description, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

                _pdfPTable.CompleteRow();
            NewLine();

        }

        private void Projects()
        {
            _fontStyle = FontFactory.GetFont("Calibri", 11f, 1);
            _fontStyle.SetColor(33, 97, 140);
            _pdfPCell = new PdfPCell(new Phrase("Projects", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            for (int i = 1; i <= 2; i++)
            {
                _fontStyle = FontFactory.GetFont("Calibri", 10f, 1);
                _fontStyle.SetColor(25, 111, 61);
                _pdfPCell = new PdfPCell(new Phrase("Cyber Security Courseware" + i, _fontStyle));
                _pdfPCell.Colspan = _totalColumn;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPTable.CompleteRow();

                _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
                _pdfPCell = new PdfPCell(new Phrase("Developed a ASP.NET Core 2.0 website for different online courses in semester project. Source code is available on GitHub at https://github.com/fawad1997/FinalWebProject.", _fontStyle));
                _pdfPCell.Colspan = _totalColumn;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPTable.CompleteRow();
            }
            NewLine();
        }

        private void Achievements()
        {
            _fontStyle = FontFactory.GetFont("Calibri", 11f, 1);
            _fontStyle.SetColor(33, 97, 140);
            _pdfPCell = new PdfPCell(new Phrase("Achievements", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            for (int i = 1; i <= 5; i++)
            {
                _fontStyle = FontFactory.GetFont("Calibri", 10f, 0);
                _pdfPCell = new PdfPCell(new Phrase("\t•    Ex-Liaison Head, IEEE CUST Chapter" + i, _fontStyle));
                _pdfPCell.Colspan = _totalColumn;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPTable.CompleteRow();
            }
            NewLine();
        }
        private void HorizontalLine()
        {
            #region Table Line
            _fontStyle = FontFactory.GetFont("Tahoma", 0f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Serial Number", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            #endregion
        }

        private void NewLine()
        {
            //New Line
            _fontStyle = FontFactory.GetFont("Arial", 10f, 0);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();
        }
    }
}
