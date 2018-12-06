Import-Module C:\Users\Daaf\source\repos\PSStubble\PSStubble\bin\Debug\PSStubble.dll
Get-Command -module PSStubble

$json = '{
  "header": "Colors",
  "items": [
      {"name": "red", "first": true, "url": "#Red"},
      {"name": "green", "link": true, "url": "#Green"},
      {"name": "blue", "link": true, "url": "#Blue"}
  ],
  "empty": false
}'


$template = '{% raw %}
<h1>{{header}}</h1>
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
{{/empty}}
{% endraw %}'

clear
Invoke-Stubble -template $template -json $json

Remove-Module -name PSStubble
start-sleep 3