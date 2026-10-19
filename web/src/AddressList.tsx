import { useEffect, useState } from "react";

type Address = {
  id: number;
  label: string;
  street: string;
  city: string;
  isDefault: boolean;
};

export default function AddressList() {
  const [addresses, setAddresses] = useState<Address[]>([]);
  const [message, setMessage] = useState("");

  useEffect(() => {
    fetch("/api/addresses")
      .then((res) => res.json())
      .then(setAddresses);
  }, []);

  async function makeDefault(id: number) {
    await fetch(`/api/addresses/${id}/default`, { method: "PUT" });
    setAddresses(addresses.map((a) => (a.id === id ? { ...a, isDefault: true } : a)));
    setMessage("Default address updated");
  }

  return (
    <main>
      <h1>My addresses</h1>
      <p>Signed in as customer 1</p>
      {message && <p role="status">{message}</p>}
      <table>
        <thead>
          <tr>
            <th>Label</th>
            <th>Street</th>
            <th>City</th>
            <th>Default</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {addresses.map((a) => (
            <tr key={a.id}>
              <td>{a.label}</td>
              <td>{a.street}</td>
              <td>{a.city}</td>
              <td>{a.isDefault ? "Default" : ""}</td>
              <td>{!a.isDefault && <button onClick={() => makeDefault(a.id)}>Make default</button>}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </main>
  );
}
