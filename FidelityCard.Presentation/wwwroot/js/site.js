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
/*
$(document).ready(function () {
    // Get the initial value of the users select box
    var initialCompanyID = $('#UserId').val();

    // Display the initial company name
    displayCompanyName(initialCompanyID);

    // Handle the change event of the users select box
    $('#UserId').change(function () {
        var selectedCompanyID = $(this).val();
        displayCompanyName(selectedCompanyID);
    });

    // Function to retrieve and display the company name based on the selected company ID
    function displayCompanyName(companyID) {
        $.ajax({
            url: '/Promos/GetCompanyName',
            type: 'GET',
            data: { companyID: companyID },
            success: function (result) {
                $('#companyName').text(result);
            }
        });
    }
});
*/