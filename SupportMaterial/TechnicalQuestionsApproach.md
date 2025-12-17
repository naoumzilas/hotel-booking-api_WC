# Open Questions

These are questions that I would normally be clarified with stakeholders before or during implementation in a real-world scenario

---

## Functional Questions

 Should multiple hotels be supported from day one, or is this intended as a single-hotel system initially?
 Should room allocation follow any priority (e.g. cheapest, smallest suitable room)?
 Is partial availability (changing rooms during a stay) ever acceptable in future versions?
 Should bookings be allowed to overlap during different times of the same day?

---

## Booking Behaviour

Should bookings be cancellable or modifiable?
 Should booking references be human-friendly or purely technical?
 Is there a requirement to prevent duplicate bookings for the same guest?

---

## Concurrency & Scale
What level of concurrent booking traffic is expected?
 Should optimistic or pessimistic locking be applied for booking creation?
 Is eventual consistency acceptable in the booking flow?

---

## Data & Reporting

 Are historical bookings ever deleted, or should they be retained indefinitely?
Will reporting or analytics be required (e.g. occupancy rates)?

---

## API & Integration

 Will this API be consumed internally, externally, or both?
 Is API versioning required from the start?
 Should rate limiting or throttling be applied?

---

## Security & Compliance

 Will authentication be required in the future?
 Are there any data protection or audit requirements?
 Should booking data be encrypted at rest?

