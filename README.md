## MyPostcodeApi

Developed using ASP.NET Core Web Api + direct query. Live demo [here](https://mypostcode.azurewebsites.net/api/postcode/ByDistrict?state=melaka&district=ayer%20keroh)

[Get postcode by address](https://github.com/pearlxcore/MyPostcodeApi#get-postcode-by-address)

[Get postcode by district](https://github.com/pearlxcore/MyPostcodeApi#get-postcode-by-district)

[State list](https://github.com/pearlxcore/MyPostcodeApi#state-list)

Get postcode by address
----
  Returns json data about address detail. **Some address may return multiple postcode due to addresses with similar name**

* **URL**

  `/api/postcode/ByAddress`

* **Method:**

  `GET`
  
* **Data Params**

   **Required:**
 
   `state=[string]`
   
   `address=[string]`
   
* **Sample Call:**

```
  curl -X 'GET' \
  'https://localhost:7173/api/postcode/ByAddress?state=melaka&address=bukit%20beruang' \
  -H 'accept: */*'
  ```
   
   
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 
    ```
    {
        "state": "MLK",
        "detail": [
            {
            "postcode": "75450",
            "address": "Bukit Beruang",
            "district": "Ayer Keroh"
            }
        ]
    }
    ```
 
* **Error Response:**

  * **Code:** 200 <br />

    **Content:** 
    ```
    {
      "state": null,
      "detail": []
    }
    ```
    
Get postcode by district
----
  Returns json data about all address detail in district

* **URL**

  `/api/postcode/ByDistrict`

* **Method:**

  `GET`
  
* **Data Params**

   **Required:**
 
   `state=[string]`
   
   `district=[string]`
   
* **Sample Call:**

```
  curl -X 'GET' \
  'https://localhost:7173/api/postcode/ByDistrict?state=melaka&district=ayer%20keroh' \
  -H 'accept: */*'
  ```
   
   
* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 
    ```
     {
        "state": "MLK",
        "detail": [
          {
            "postcode": "75450",
            "address": "Air Keroh D Village Resort",
            "district": "Ayer Keroh"
          },
          {
            "postcode": "75450",
            "address": "Ayer Keroh Country Resort",
            "district": "Ayer Keroh"
          },
          {
            "postcode": "75450",
            "address": "Bangunan LHDN Hang Tuah Jaya",
            "district": "Ayer Keroh"
          },
          {
            "postcode": "75450",
            "address": "Bangunan TM Hang Tuah Jaya",
            "district": "Ayer Keroh"
          }
          ...
     }
    ```
 
* **Error Response:**

  * **Code:** 200 <br />

    **Content:** 
    ```
    {
      "state": null,
      "detail": []
    }
    ```
    
## State list
   ```
   johor
   kedah
   kelantan
   kuala_lumpur
   labuan
   melaka
   negeri_sembilan
   pahang
   penang
   perak
   perlis
   putrajaya
   sabah
   sarawak
   selangor
   terengganu
   ```
   
## Credit 
[heiswayi](https://github.com/heiswayi/malaysia-postcodes) for postcode list
