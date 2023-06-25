// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Unhidding in HTML
$(document).ready(function () {
    $(".unhideFunctions").change(function () {

        $(".initiallyHidden").show(20);
    });
});

// Creating a company information based on the choice of a user in Promotions
document.addEventListener('DOMContentLoaded', function () {
    var userSelect = document.getElementById('UserId');
    userSelect.addEventListener('change', createCompanyDiv);
});

function createCompanyDiv() {
    var selectedUser = this.value;
    var companyContainer = document.getElementById('companyContainer');
    companyContainer.innerHTML = '';

    if (selectedUser !== '') {
        var companyDiv = document.createElement('div');
        var userValues = selectedUser.split(',');
        var companyId = userValues[1]; // Extract the companyId from the user value
        companyDiv.id = 'company_' + companyId;
        companyDiv.textContent = 'Company ID: ' + companyId;
        companyContainer.appendChild(companyDiv);
    }
}