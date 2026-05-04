## MyPostcodeApi

Malaysian postcode lookup API covering all 16 states with 53,000+ entries. All endpoints are read-only `GET` and return JSON.

**Base URL:** `https://mypostcodeapi.pearlxcore.dev/api/postcode`

---

### Endpoints

#### `GET /States`
Returns all valid state parameter values. Use this to populate dropdowns or validate input.

```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/States
```

```json
["johor","kedah","kelantan","kuala_lumpur","labuan","melaka",
 "negeri_sembilan","pahang","penang","perak","perlis",
 "putrajaya","sabah","sarawak","selangor","terengganu"]
```

---

#### `GET /Districts?state={state}`
Returns all distinct districts (cities) within a state. Useful for autocomplete or listing available areas.

```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/Districts?state=penang
```

```json
{
    "state": "penang",
    "districts": ["Ayer Itam", "Balik Pulau", "Butterworth", "Gelugor", "Jelutong", ...]
}
```

---

#### `GET /ByPostcode?postcode={postcode}`
Reverse lookup — finds all addresses and districts matching a postcode number. Searches across all states.

```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/ByPostcode?postcode=81920
```

```json
{
    "state": "JHR",
    "detail": [
        { "postcode": "81920", "address": "Ayer Tawar 2", "district": "Ayer Tawar 2" },
        { "postcode": "81920", "address": "Ayer Tawar",   "district": "Ayer Tawar 2" },
        { "postcode": "81920", "address": "Felda Air Tawar 5", "district": "Ayer Tawar 2" }
    ]
}
```

---

#### `GET /ByAddress?state={state}&address={address}`
Exact-match lookup by street address within a given state.

```
curl "https://mypostcodeapi.pearlxcore.dev/api/postcode/ByAddress?state=selangor&address=Bukit%20Raja%20Selatan"
```

---

#### `GET /ByDistrict?state={state}&district={district}`
Exact-match lookup by district name. Returns all addresses within that district. Combine with `/Districts` to discover valid district names first.

```
curl "https://mypostcodeapi.pearlxcore.dev/api/postcode/ByDistrict?state=johor&district=Ayer%20Tawar%202"
```

---

### Typical workflow

```
States → Districts?state=x → ByDistrict?state=x&district=y → ByPostcode?postcode=z
```

### Response codes

| Code | Meaning |
|---|---|
| 200 | Data returned |
| 404 | No match or invalid state |

### Data model

| Field | Description |
|---|---|
| `state` | State abbreviation (e.g. JHR, SGR, PNG) |
| `postcode` | 5-digit postcode |
| `address` | Street address |
| `district` | City / district name |

### Credit

[heiswayi](https://github.com/heiswayi/malaysia-postcodes) for the postcode dataset.
