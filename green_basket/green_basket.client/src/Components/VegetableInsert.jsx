// src/components/VegetableInsertForm.js
import React from 'react';
import { useForm } from 'react-hook-form';

const VegetableInsertForm = ({ onSubmit }) => {
    const { register, handleSubmit, formState: { errors } } = useForm();

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <div>
                <label htmlFor="vegetable_name">Vegetable Name</label>
                <input
                    id="vegetable_name"
                    {...register("vegetable_name", {
                        required: "Vegetable name is required.",
                        maxLength: {
                            value: 100,
                            message: "Vegetable name can't be longer than 100 characters."
                        }
                    })}
                />
                {errors.vegetable_name && <p>{errors.vegetable_name.message}</p>}
            </div>

            <div>
                <label htmlFor="image_url">Image URL</label>
                <input
                    id="image_url"
                    type="url"
                    {...register("image_url", {
                        required: "Image URL is required.",
                        pattern: {
                            value: /^(https?:\/\/[^\s$.?#].[^\s]*)$/,
                            message: "Invalid URL format."
                        }
                    })}
                />
                {errors.image_url && <p>{errors.image_url.message}</p>}
            </div>

            <div>
                <label htmlFor="vegetable_price">Vegetable Price</label>
                <input
                    id="vegetable_price"
                    type="number"
                    step="0.01"
                    {...register("vegetable_price", {
                        required: "Vegetable price is required.",
                        min: {
                            value: 0.01,
                            message: "Vegetable price must be greater than 0."
                        }
                    })}
                />
                {errors.vegetable_price && <p>{errors.vegetable_price.message}</p>}
            </div>

            <div>
                <label htmlFor="quantity">Quantity</label>
                <input
                    id="quantity"
                    type="number"
                    {...register("quantity", {
                        required: "Quantity is required.",
                        min: {
                            value: 1,
                            message: "Quantity must be at least 1."
                        }
                    })}
                />
                {errors.quantity && <p>{errors.quantity.message}</p>}
            </div>

            <button type="submit">Insert Vegetable</button>
        </form>
    );
};

export default VegetableInsertForm;
