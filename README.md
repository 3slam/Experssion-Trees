 
<h1>Filtering with Expression Trees in .NET MVC</h1>

<p>This project demonstrates how to use <strong>Expression Trees</strong> in a .NET Core MVC application to enhance the performance of filtering large datasets. The application is designed to filter passenger information based on various criteria (like survival, class, sex, and age) using two approaches: basic LINQ queries and dynamically constructed queries with <strong>Expression Trees</strong>.</p>

<h2>Project Overview</h2>

<p>The application showcases two different methods for filtering passenger data:</p>
<ul>
    <li><strong>LINQ-based filtering (<code>filterV1</code>)</strong>: A simple in-memory filtering using <code>Where()</code> clauses.</li>
    <li><strong>Expression Tree-based filtering (<code>filterV2</code>)</strong>: A more advanced approach where queries are built dynamically, executed at the database level, and provide better performance for large datasets.</li>
</ul>

<h2>Features</h2>
<ul>
    <li><strong>Passenger Data Management</strong>: Displays a list of passengers from the database and allows filtering based on user-defined criteria.</li>
    <li><strong>Dynamic Querying with Expression Trees</strong>: Optimizes filtering by constructing queries at runtime, which are executed directly in the database.</li>
    <li><strong>Comparative Filtering</strong>: Compare the performance and approach of LINQ vs Expression Trees.</li>
</ul>

<h2>Prerequisites</h2>
<ul>
    <li><a href="https://dotnet.microsoft.com/download" target="_blank">.NET Core SDK</a> (version 6.0 or higher)</li>
    <li>SQL Server or any database supported by Entity Framework Core</li>
    <li>An IDE like Visual Studio or JetBrains Rider</li>
</ul>

<h2>Project Structure</h2>
<ul>
    <li><strong>Controllers</strong>:
        <ul>
            <li><code>HomeController</code>: Contains the logic for displaying the list of passengers and filtering them.</li>
        </ul>
    </li>
    <li><strong>Models</strong>:
        <ul>
            <li><code>PassengerInfo</code>: Represents the model for passenger data, including properties like <code>Survived</code>, <code>PassengerClass</code>, <code>Sex</code>, and <code>Age</code>.</li>
            <li><code>PassengerFilterViewModel</code>: Holds the filtering criteria provided by the user.</li>
            <li><code>PassengerViewModel</code>: Combines the list of passengers and the applied filter for display in the view.</li>
        </ul>
    </li>
    <li><strong>Views</strong>:
        <ul>
            <li><code>Index.cshtml</code>: The main view that shows the passenger data and provides the filtering form.</li>
        </ul>
    </li>
</ul>

<h2>Filtering Methods</h2>

<h3>1. LINQ-based Filtering (<code>filterV1</code>)</h3>
<p>In this method, the filtering is applied using standard LINQ <code>Where()</code> clauses, and the entire result set is filtered in-memory. This is simpler but may not perform well with large datasets as all data is loaded into memory first.</p>

<h3>2. Expression Tree-based Filtering (<code>filterV2</code>)</h3>
<p>In this method, we use <strong>Expression Trees</strong> to dynamically construct queries that are executed at the database level. This avoids loading the entire dataset into memory and enhances performance, especially for larger datasets.</p>

<h2>How to Run the Project</h2>
<ol>
    <li>Clone the repository or download the project files.</li>
    <li>Open the project in your preferred IDE (e.g., Visual Studio).</li>
    <li>Run the project by pressing <code>F5</code> or using the Run button.</li>
</ol>

<h2>Contributing</h2>
<p>Feel free to fork this repository and submit pull requests to enhance the project or improve the filtering logic.</p>

</body>
</html>
