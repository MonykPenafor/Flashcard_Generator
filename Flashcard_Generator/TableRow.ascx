<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableRow.ascx.cs" Inherits="Flashcard_Generator.TableRow" %>


<td class="flashcad-table-row-cell"><%= FlashcardTableRow.WordTarget %> <br /> <%= FlashcardTableRow.WordSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.ExampleSentenceTarget %> <br /> <%= FlashcardTableRow.Pronunciation%> <br /> <%= FlashcardTableRow.ExampleSentenceSource%></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Tips %></td>
<td class="flashcad-table-row-cell"><%= FlashcardTableRow.Proficiency %></td>


<td class="flashcad-table-row-cell"><button runat="server" type="button" class="td-icon" onclick="deleteFlashcard()"><img src="assets/icons/bin.png" alt="delete"/></button></td>
<td class="flashcad-table-row-cell"><button type="button" class="td-icon" onclick='showModal(<%# FlashcardTableRow.Id %>)'><img src="assets/icons/edit.png" alt="edit"/></button></td>


<input type="hidden" value='<%# FlashcardTableRow.Id %>' id="fcid" runat="server"/>

<span><button visible="false" type="button" runat="server" class="btnfcidDelete" onserverclick="btnDeleteFlashcard_Click"></button></span>
<span><button visible="false" type="button" runat="server" class="btnfcidEdit" onserverclick="btnEditFlashcard_Click"></button></span>


<%-- 



<td ><asp:LinkButton runat="server" type="button" CommandArgument='<%# FlashcardTableRow.Id %>' OnClick="btnEditFlashcard_Click" CssClass="td-icon"><img src="assets/icons/edit.png" alt="edit"/></asp:LinkButton></td>
<td class="flashcad-table-row-cell"><asp:LinkButton runat="server" CommandArgument='<%# FlashcardTableRow.Id %>' OnClick="btnDeleteFlashcard_Click" CssClass="td-icon"><img src="assets/icons/bin.png" alt="delete"/></asp:LinkButton></td>

<input type="hidden" value='<%# FlashcardTableRow.Id %>' id="ide" runat="server"/>

<td class="flashcad-table-row-cell"><linkbutton type="button" onclick="showModal(<%# FlashcardTableRow.Id %>)" class="td-icon"><img src="assets/icons/edit.png" alt="edit"/></linkbutton></td>
<td class="flashcad-table-row-cell"><linkbutton type="button" data-flashcard-id="<%# FlashcardTableRow.Id %>" onclick="deleteFlashcard(<%# FlashcardTableRow.Id %>)" class="td-icon excluirFlashcard"><img src="assets/icons/bin.png" alt="delete"/></linkbutton></td>
<td class="flashcad-table-row-cell"><button type="button" runat="server" data-flashcard-id="<%# FlashcardTableRow.Id %>" class="excluirFlashcard"><img src="assets/icons/bin.png" alt="delete"/></button></td>









--%>




