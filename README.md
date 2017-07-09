# Sc.AutoCompleteTextField

Sitecore Single-line Text Field with suggestions and autocomplete features

## Usage
* Create class which inherits from SmartSitecore.AutoCompleteTextField.Fields.AutoCompleteTextField and implement GetServiceUrl method: 
  * It should return url to ajax web method like `"/api/sitecore/StylesAutoComplete/Load"`. 
  * This method can be created elsewhere as WebMethod or MVC GET and should have `string query` input parameter and return list of string as json object, like:
    ```
    {
      "suggestions": [
        { "value": "United Kingdom",       "data": "UK" },
        { "value": "United States",        "data": "US" }
      ]
    }
    ```
    For details check [jQuery-Autocomplete](https://github.com/devbridge/jQuery-Autocomplete)
* Create new field type in Sitecore core database, poiting to your class and use it in your templates 

