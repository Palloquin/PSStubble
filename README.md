# PSStubble
A PowerShell implementation of Stubble (https://github.com/StubbleOrg/Stubble). 
Use Mustache (https://mustache.github.io/) templates in PowerShell scripts 

PSStubble will give you the Invoke-Stubble cmdlet

```
NAME
    Invoke-Stubble
    
SYNTAX
    Invoke-Stubble [-template <string>] [-json <string>] [-useCustomWhiteSpaceClearner]  [<CommonParameters>]
    
    
PARAMETERS
    -json <string>
        
        Required?                    false
        Position?                    Named
        Accept pipeline input?       false
        Parameter set name           (All)
        Aliases                      None
        Dynamic?                     false
        
    -template <string>
        
        Required?                    false
        Position?                    Named
        Accept pipeline input?       false
        Parameter set name           (All)
        Aliases                      None
        Dynamic?                     false
        
    -useCustomWhiteSpaceClearner
        
        Required?                    false
        Position?                    Named
        Accept pipeline input?       false
        Parameter set name           (All)
        Aliases                      None
        Dynamic?                     false
        
    <CommonParameters>
        This cmdlet supports the common parameters: Verbose, Debug,
        ErrorAction, ErrorVariable, WarningAction, WarningVariable,
        OutBuffer, PipelineVariable, and OutVariable. For more information, see 
        about_CommonParameters (https:/go.microsoft.com/fwlink/?LinkID=113216). 
    
    
INPUTS
    None
    
    
OUTPUTS
    System.String
    
    
ALIASES
    None
    

REMARKS
    None
```


## Custom white-space clearner     
I had issues with white-spaces and newlines in plain text templates. I solved this by extending Mustache with my own tags :
When using the -useCustomWhiteSpaceClearner switch

this template:
```
This is what we know about {{name}}: 
{|{{#colour}}- Favourite colour is {{colour}}{{/colour}}|}
{|{{#fruit}}- Favourite fruit is {{fruit}}{{/fruit}}|}
{|{{#book}}- Favourite book is {{book}}{{/book}}|}
```

will render as:
```
This is what we know about James: 
- Favourite colour is green
- Favourite book is War and peace
```
