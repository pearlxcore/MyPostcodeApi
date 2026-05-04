## MyPostcodeApi

Malaysian postcode lookup API. Returns postcode, address, and district data for all 16 Malaysian states.

**Live:** `https://mypostcodeapi.pearlxcore.dev/api/postcode/`

### Endpoints

| Endpoint | Method | Params |
|---|---|---|
| `/api/postcode/States` | GET | — |
| `/api/postcode/ByPostcode` | GET | `postcode` |
| `/api/postcode/ByAddress` | GET | `state`, `address` |
| `/api/postcode/ByDistrict` | GET | `state`, `district` |
| `/api/postcode/Districts` | GET | `state` |

### States

```
johor kedah kelantan kuala_lumpur labuan melaka
negeri_sembilan pahang penang perak perlis
putrajaya sabah sarawak selangor terengganu
```

### Examples

**Get all states:**
```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/States
```

**Lookup by postcode:**
```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/ByPostcode?postcode=81920
```

**Lookup by address:**
```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/ByAddress?state=johor&address=Ayer%20Tawar
```

**Lookup by district:**
```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/ByDistrict?state=johor&district=Ayer%20Tawar%202
```

**List districts in a state:**
```
curl https://mypostcodeapi.pearlxcore.dev/api/postcode/Districts?state=penang
```

### Response

**200:**
```json
{
    "state": "JHR",
    "detail": [
        {
            "postcode": "81920",
            "address": "Ayer Tawar 2",
            "district": "Ayer Tawar 2"
        }
    ]
}
```

**404:** Not found — no matching data or invalid state.

### Credit

[heiswayi](https://github.com/heiswayi/malaysia-postcodes) for postcode list
