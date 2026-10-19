# Code Challenge — My addresses (30 minutes)

## The situation

An AI coding assistant implemented ticket **ACC-210** below, across a .NET API and a React page. The code builds, the tests pass, and the page loads. That does not mean it meets the ticket. Your job is to review it, fix it, and extend it.

You may use your usual AI assistant while fixing and extending the code. Please share your screen and explain what you ask it and how you check what it gives you.

## Ticket ACC-210 — My addresses

A signed-in customer manages the shipping addresses saved in their account. In this project you are always signed in as **customer 1**.

**Acceptance criteria**

1. The customer sees only their own saved addresses.
2. The customer can mark one address as the default. Only one address can be the default at a time.
3. The default address is listed first.
4. After the customer marks a new default, the list shows the change without reloading the page.
5. If the operation fails, the customer sees an error message, never a success message.
6. A customer can never see or change another customer's addresses.

## Steps

1. **Review (10 minutes).** Read the code against the ticket. Tell us what is wrong, which acceptance criterion each problem breaks, and what you would fix first. Do not change code yet.
2. **Fix (10 minutes).** Fix the problems you found and show how you verified each fix.
3. **Extend (10 minutes).** A new acceptance criterion is added to the ticket:

   > 7. A customer can delete one of their addresses, but never the default one.

   Implement it in the API, with a test, and add a delete button to the list. If time is short, the API change and its test are enough.

## Rules

- Keep the existing code; do not rewrite it from scratch.
- Check the code against the ticket; do not assume it is correct because it builds or because the tests pass.
- If you use an AI assistant, review every change it proposes before accepting it.
- Do not add new libraries.

## Running the project

The Codespace installs everything when it starts. Then, in two terminals:

```bash
cd api && dotnet run          # API on http://localhost:5080
cd web && npm run dev         # page on http://localhost:5173
```

Tests: `dotnet test api.tests`

## Files

- `api/Controllers/AddressesController.cs`: the API endpoints.
- `api/Data/AppDbContext.cs`: the data model and the sample data (an in-memory database).
- `api/Auth/DemoAuthHandler.cs`: signs every request in as a customer (customer 1 unless the `X-Customer-Id` header says otherwise). It stands in for real authentication.
- `api.tests/AddressesApiTests.cs`: the existing tests.
- `web/src/AddressList.tsx`: the page.

Think out loud as you work. We are interested in how you reason, not only in the final code.
