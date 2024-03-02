import React from "react";

export default function PageHeader({ title }) {
  return (
        <div class="page-header mb-0">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <h2>{ title }</h2>
                    </div>
                    <div class="col-12">
                        <a href="">Home</a>
                        <a href="">{ title }</a>
                    </div>
                </div>
            </div>
        </div>
  );
}
