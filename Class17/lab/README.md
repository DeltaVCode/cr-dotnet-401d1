# Lab 17: DTOs and Routing

## Assignment Specifications

1. Refactor your code to output a modified version of your entity. This improves both security and readability on your data to your client. 

The Routes, Responses, and DTOS are included below. Refactor your code to match what is provided. 


### Routes and Responses

#### HotelsController

Route (GET): api/Hotels/{id}:

```
{
    "id": 1,
    "name": "My really cool Hotel",
    "streetAddress": "123 CandyCane Lane",
    "city": "Seattle",
    "state": "WA",
    "phone": "123-456-8798",
    "rooms": [
        {
            "hotelID": 1,
            "roomNumber": 101,
            "rate": 75.00,
            "petFriendly": false,
            "roomID": 2,
            "room": {
                "id": 2,
                "name": "Queen Suite",
                "layout": "TwoBedroom",
                "amenities": [
                    {
                        "id": 1,
                        "name": "Coffee Maker"
                    },
                    {
                        "id": 2,
                        "name": "Mini Bar"
                    }
                ]
            }
        },
        {
            "hotelID": 1,
            "roomNumber": 123,
            "rate": 120.00,
            "petFriendly": true,
            "roomID": 1,
            "room": {
                "id": 1,
                "name": "Princess Suite",
                "layout": "OneBedroom",
                "amenities": [
                    {
                        "id": 1,
                        "name": "Coffee Maker"
                    },
                    {
                        "id": 2,
                        "name": "Mini Bar"
                    }
                ]
            }
        }
    ]
}
```

Route: (GET) :  'api/Hotels'

```
An array of individual hotels. (See result from api/Hotels/{id})
``` 

#### HotelRooms Controller

Route: (Get/Put/) : `api/hotel/room/{hotelId}/{roomNumber}`
- This is the HotelRooms Controller
- Retrieve and update a hotel room
- PUT will include the HotelRoomDTO in the request

```
{
    "hotelID": 1,
    "roomNumber": 101,
    "rate": 75.00,
    "petFriendly": false,
    "roomID": 2,
    "room": {
        "id": 2,
        "name": "Queen Suite",
        "layout": "TwoBedroom",
        "amenities": [
            {
                "id": 1,
                "name": "Coffee Maker"
            },
            {
                "id": 2,
                "name": "Mini Bar"
            }
        ]
    }
}
```

Route: (POST) : `api/hotel/room/{hotelId}`
- Add a new Hotel Room to a hotel
- HotelRoomDTO will be included in RequestBody

#### Rooms Controller

Route (Get/Put) : `api/rooms/{roomId}`
- Get a specific room
- Update a room

```
{
    "id": 1,
    "name": "Princess Suite",
    "layout": "OneBedroom",
    "amenities": [
        {
            "id": 1,
            "name": "Coffee Maker"
        },
        {
            "id": 2,
            "name": "Mini Bar"
        }
    ]
}
```

Route: (GET/POST) : `api/rooms/`
- Get an array of RoomDTO objects
- refer to request above for formatting
-  Post request will create a new room
- Post request will have the room DTO included in request

#### Amenities Controller
Route: (Get) `api/amenities/{id}`
- Get specific amenity

```
{
    "id": 1,
    "name": "Coffee Maker"
}
```

Route: (GET/POST) - `api/amenities/`
- Get all Amenities 
- Response will be an array of amenities
- Post is adding a new general amenity
- Post will include the Amenities DTO in the request

#### RoomAmenities Controller

Route: (POST) `api/room/amenities/{roomId}/{amenitiesId}`
- Add a amenity to a specific room
- No request body, just the amenity ID

### DTOs

```csharp
    public class HotelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }


    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }

    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public List<AmenityDTO> Amenities { get; set; }
    }

    public class AmenityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
```


## Guidance
- There is no additional guidance for this assignment.

## Unit Tests

N/A

## Stretch Goals

- Implement Cascade deletion?

## Additional Resources
- There are no additional resources provided for this assignment.

## README



## Rubric

The lab rubric can be found [Here](../../Resources/rubric){:target="_blank"} 

## To Submit this Assignment

- Create a new branch named `NAME-Lab#` in your `AsyncInn` repository
- Write your code
- Commit often
- Push to your repository
- Create a pull request from your branch back your `master` branch.
- Submit a link to your PR in Canvas
- Merge your PR back into master
- In Canvas, Include the actual time it took you to complete the assignment as a comment (**REQUIRED**)
- Include a `README.md` (contents described above)