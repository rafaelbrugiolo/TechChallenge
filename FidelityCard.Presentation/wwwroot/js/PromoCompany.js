// Creating a Company/Product information based on the choice of a user in Promotions
function initializeUserSelection() {
    var itemID = $('#UserId').val();
    displayCompanyName(itemID);
    displayListOfProducts(itemID);

    // Handle the change event of the users select box
    $('#UserId').change(function () {
        var selectedItemID = $(this).val();
        displayCompanyName(selectedItemID);
    });

    // The Functions below retrieve and display:

    // NAME OF THE COMPANY
    function displayCompanyName(companyID) {
        $.ajax({
            url: '/Companies/GetById/' + companyID,
            type: 'GET',
            success: function (result) {
                $('#companyName').text(result);
            }
        });
    }

    // LIST OF PRODUCTS
    function displayListOfProducts(companyID) {
        $.ajax({
            url: '/Products/GetByCompanyId/' + companyID,
            type: 'GET',
            success: function (products) {
                var select = $('#ProductId');
                select.empty()
                select.append($('<option>').text(' -- Choose a product --'))
                $.each(products, function (_, product) {
                    var option = $('<option>', {
                        value: product.id,
                        text: product.description
                    });
                    select.append(option);
                });
            },
        })
    }
};