The following assumptions were made while implementing the Hotel Booking API, as they were not explicitly defined in the assessment brief.

---

## General Assumptions

- The system supports **a small number of hotels** and is not optimized for high concurrency.
- Bookings are processed synchronously without distributed locks.
- The API is intended for demonstration purposes rather than production deployment.

---

## Booking & Availability

- `CheckOut` dates are treated as **exclusive** (standard hotel behaviour).
- A booking occupies the room for every night from `CheckIn` up to (but not including) `CheckOut`.
- The first available room that satisfies all criteria is selected when booking.
- No pricing logic is included, as pricing was not part of the requirements.

---

## Data & Persistence

- SQLite is used for simplicity and zero-setup execution.
- Database schema is created automatically at startup using `EnsureCreated()`.
- EF Core migrations were intentionally not included to reduce setup friction for reviewers.

---

## API Design

- POST endpoints are used for search operations with complex request payloads to improve Swagger and Postman usability.
- Request and response models are defined explicitly in the Application layer.
- Controllers do not contain business logic and act only as HTTP adapters.

---

## Testing

- Unit testing is demonstrated but not exhaustive.
- The focus is on structure and testability rather than coverage.
- No integration tests are included due to time and scope constraints.

---

## Security

- No authentication or authorization is implemented, as explicitly stated in the assessment brief.