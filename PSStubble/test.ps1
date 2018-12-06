Write-Host 'Importing module:' -ForegroundColor Green;

Import-Module .\PSStubble.dll;

Get-help Invoke-Stubble -full;

Write-Host 'Press any key to continue...'  -ForegroundColor Yellow;
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');

$json = '{
  "header": "Colors",
  "items": [
      {"name": "red", "first": true, "url": "#Red"},
      {"name": "green", "link": true, "url": "#Green"},
      {"name": "blue", "link": true, "url": "#Blue"}
  ],
  "empty": false
}'


$template = '<h1>{{header}}</h1>
{{#bug}}
{{/bug}}

{{#items}}
  {{#first}}
    <li><strong>{{name}}</strong></li>
  {{/first}}
  {{#link}}
    <li><a href="{{url}}">{{name}}</a></li>
  {{/link}}
{{/items}}

{{#empty}}
  <p>The list is empty.</p>
{{/empty}}'

clear;
Write-Host  'Testing merge:'  -ForegroundColor Green;
Invoke-Stubble -template $template -json $json;

Write-Host 'Press any key to continue...' -ForegroundColor Yellow;
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');

