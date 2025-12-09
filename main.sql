CREATE TABLE employees (
    id SERIAL PRIMARY KEY,               -- Auto-incrementing unique ID
    first_name VARCHAR(50) NOT NULL,     -- Text, cannot be empty
    last_name VARCHAR(50) NOT NULL,      -- Text, cannot be empty
    email VARCHAR(100) UNIQUE NOT NULL,  -- Text, must be unique across all rows
    salary INTEGER CHECK (salary > 0),   -- Number, must be positive
    hire_date DATE DEFAULT CURRENT_DATE, -- Date, defaults to today if skipped
    is_active BOOLEAN DEFAULT TRUE       -- True/False
);

INSERT INTO employees (first_name, last_name, email, salary)
VALUES ('Ali', 'Yilmaz', 'ali@example.com', 50000);

SELECT * FROM employees;