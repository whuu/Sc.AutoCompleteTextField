# Sc.AutoCompleteTextField

Sitecore Single-line Text Field with suggestions and autocomplete features

## Usage
* Create class which inherits from SmartSitecore.AutoCompleteTextField.Fields.AutoCompleteText and implement GetServiceUrl method: 
  * It should return url to ajax web method like `"/api/sitecore/StylesAutoComplete/Load"`. 
  * This method can be created elsewhere as WebMethod or MVC GET and should return list of string as json object, like:
    ```
    {
      "suggestions": [
        { "value": "UK",       "data": "UK" },
        { "value": "US",        "data": "US" }
      ]
    }
    ```
    For details check [jQuery-Autocomplete](https://github.com/devbridge/jQuery-Autocomplete)
* Create new field type in Sitecore core database under `/sitecore/system/Field types`, pointing to your class and assembly, use new field in your templates. 
* For sample usage visit [Css Picker Project](https://github.com/whuu/Sc.CssPickerField)

