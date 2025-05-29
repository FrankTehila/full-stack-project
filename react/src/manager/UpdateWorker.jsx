import React, { useState } from "react";

const UpdateWorker = () => {
    const [form, setForm] = useState({
        id: "",
        email: "",
        firstName: "",
        lastName: "",
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setForm((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        // שלח את הנתונים לשרת (עדכן את ה-URL בהתאם)
        await fetch("http://localhost:5036/api/Worker/UpdateWorker", {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                id: Number(form.id),
                email: form.email || undefined,
                firstName: form.firstName || undefined,
                lastName: form.lastName || undefined
            }),
        });
        setForm({
            id: "",
            email: "",
            firstName: "",
            lastName: "",
        });
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>ID:</label>
                <input
                    type="number"
                    name="id"
                    value={form.id}
                    onChange={handleChange}
                    required
                />
            </div>
            <div>
                <label>First Name:</label>
                <input
                    type="text"
                    name="firstName"
                    value={form.firstName}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label>Last Name:</label>
                <input
                    type="text"
                    name="lastName"
                    value={form.lastName}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label>Email:</label>
                <input
                    type="email"
                    name="email"
                    value={form.email}
                    onChange={handleChange}
                />
            </div>
            <button type="submit">עדכן</button>
        </form>
    );
};

export default UpdateWorker;