Tutorial: implement Role-Based Authentication in ASP.NET Core 9 Web API

To login:
curl -X 'POST' 'https://localhost:7178/api/auth/login'   -H 'accept: */*' -H 'Content-Type: application/json'   -d '{  "email": "yan@usi.edu",  "password": "Test123+"}'

curl -X 'POST' 'https://localhost:7178/api/auth/register'   -H 'accept: */*' -H 'Content-Type: application/json'   -d '{  "email": "yan@usi.edu",  "password": "Test123+"}'

**curl -X GET https://127.0.0.1:7178/api/secure -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFuQHVzaS5lZHUiLCJqdGkiOiI0ZGZmMmViNi05NWRhLTQyMDAtODkxMi05YjU4NDA5YmM2NmYiLCJleHAiOjE3NzU1MDc1MzV9.eKGrwi7t6uL81BC8e0LnAaz_ejqYgmk2bS6ixC2GkSE"

curl -X GET https://127.0.0.1:7178/WeatherForecast -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieWFuQHVzaS5lZHUiLCJqdGkiOiI0ZGZmMmViNi05NWRhLTQyMDAtODkxMi05YjU4NDA5YmM2NmYiLCJleHAiOjE3NzU1MDc1MzV9.eKGrwi7t6uL81BC8e0LnAaz_ejqYgmk2bS6ixC2GkSE"
**
<img width="975" height="233" alt="image" src="https://github.com/user-attachments/assets/bc068e91-e456-4c66-a133-79d7d51fb34d" />


