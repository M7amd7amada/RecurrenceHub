# RecurrenceHub API Documentation

## Authentication

### Register

- **URL**: `/api/auth/Register`
- **Method**: `POST`
- **Description**: Registers a new user by accepting their details.
- **Content-Type**: `application/json`

#### Request Body

| Field      | Type   | Required | Description               |
|------------|--------|----------|---------------------------|
| `firstName`| string | Yes      | First name of the user    |
| `lastName` | string | Yes      | Last name of the user     |
| `email`    | string | Yes      | Email address of the user |
| `password` | string | Yes      | Password for the user     |

#### Example Request

```json
POST /api/auth/Register
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "password": "Password123!"
}
```

#### Success Response

- **Status**: `200 OK`
- **Content**:

  ```json
  {
      "id": "e7f6f48f-1234-5678-9abc-def123456789",
      "firstName": "John",
      "lastName": "Doe",
      "email": "john.doe@example.com",
      "token": "your_jwt_token_here"
  }
  ```

### Login

- **URL**: `/api/auth/Login`
- **Method**: `POST`
- **Description**: Authenticates a user and returns an authentication token.
- **Content-Type**: `application/json`

#### Request Body

| Field     | Type   | Required | Description               |
|-----------|--------|----------|---------------------------|
| `email`   | string | Yes      | Email address of the user |
| `password`| string | Yes      | Password for the user     |

#### Example Request

```json
POST /api/auth/Login
{
    "email": "john.doe@example.com",
    "password": "Password123!"
}
```

#### Success Response

- **Status**: `200 OK`
- **Content**:

  ```json
  {
      "id": "e7f6f48f-1234-5678-9abc-def123456789",
      "firstName": "John",
      "lastName": "Doe",
      "email": "john.doe@example.com",
      "token": "your_jwt_token_here"
  }
  ```

### Error Responses

Both endpoints may return the following error responses:

- **400 Bad Request**: Missing or invalid fields in the request body.
- **401 Unauthorized**: Incorrect email or password for the `Login` endpoint.

### Sample Error Response

```json
{
    "error": "Invalid email or password"
}
```