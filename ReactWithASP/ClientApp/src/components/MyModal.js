// Popup.js
import React from 'react';
import './Popup.css'; // Import your CSS for styling

const Popup = ({ content, handleClose }) => {
    return (
        <div className="popup-overlay">
            <div className="popup-content">
                <div className="popup-inner-content">
                    {content}
                </div>
            </div>
        </div>
    );
};

export default Popup;