using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppV_vici_V.Models;

namespace TestAppV_vici_V
{
    public static class MyHtmlHalpers
    {
        public static MvcHtmlString MyTableMessage(this HtmlHelper html, List<MessgeMod> mess, string ClassNameTable, string ClassNameUser, string ClassNameMessage, string ClassNameDT)
        {
            TagBuilder Table = new TagBuilder("table");

            Table.MergeAttribute("class", ClassNameTable);

            TagBuilder tr = new TagBuilder("tr");
            tr.InnerHtml += html.TableData("Пользователь", ClassNameUser);
            tr.InnerHtml += html.TableData("Сообщение", ClassNameMessage);
            tr.InnerHtml += html.TableData("Дата - время", ClassNameDT);

            Table.InnerHtml += tr.ToString();

            foreach (MessgeMod m in mess)
            {
                Table.InnerHtml += html.TableRow(m, ClassNameUser, ClassNameMessage, ClassNameDT);
            }
            

            return new MvcHtmlString(Table.ToString());
        }

        static MvcHtmlString TableRow(this HtmlHelper html, MessgeMod mess, string ClassNameUser, string ClassNameMessage, string ClassNameDT)
        {
            TagBuilder tr = new TagBuilder("tr");

            tr.InnerHtml += html.TableData(mess.User.Nick, ClassNameUser);
            tr.InnerHtml += html.TableData(mess.Mess, ClassNameMessage);
            tr.InnerHtml += html.TableData(mess.Time.ToString("H-mm-ss dd/MM/yyyy"),ClassNameDT);


            return new MvcHtmlString(tr.ToString());
        }

        static MvcHtmlString TableData(this HtmlHelper html, string Item, string ClassName)
        {
            TagBuilder td = new TagBuilder("td");
            td.MergeAttribute("class", ClassName);

            td.InnerHtml += "<div><xmp>"+Item+"</xmp></div>";

            return new MvcHtmlString(td.ToString());
        }
    }
}