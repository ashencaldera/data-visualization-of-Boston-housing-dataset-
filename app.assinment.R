library(shiny)
library(ggplot2)
library(caret)
library(MASS)

##exploring data

#loading data set
boston = read.csv('https://raw.githubusercontent.com/selva86/datasets/master/BostonHousing.csv')

#assigning proper column names
colnames(boston) = c("CRIME", "LANDZONE", "NONBUSI", "RIVER", "NITRO", "ROOMS", "AGE", "DISTANCE", "RADIAL", "TAX", "PUPIL", "BLACK", "POPULA", "MEDIAN")

#head in data set
head(boston)

#checking missing values
nullvalues=is.na(boston)
print(nullvalues)

#structure of data set
str(boston)

#summary of data set
summary(boston)


#define UI for application
  ui = fluidPage(
    titlePanel("Boston Housing dataset"),
    sidebarLayout(
      sidebarPanel(
        selectInput("xvar", "X-axis variable", choices = names(boston)),
        selectInput("yvar", "Y-axis variable", choices = names(boston), selected = "MEDIAN")
      ),
      mainPanel(
        plotOutput("scatterPlot")
      )
    )
  )
  
  server <- function(input, output) {
    output$scatterPlot <- renderPlot({
      ggplot(boston, aes_string(x = input$xvar, y = input$yvar)) +
        geom_point() +
        labs(title = paste("Scatter plot of", input$xvar, "vs", input$yvar))
    })
  }
  boston_data <- Boston
  # Create a new variable that categorizes the average number of rooms into ranges
  boston_data$rm_range <- cut(boston_data$rm, 
                              breaks = seq(min(boston_data$rm), max(boston_data$rm), by = 1), 
                              include.lowest = TRUE)
  
  # Convert rm_range to a factor
  boston_data$rm_range <- as.factor(boston_data$rm_range)
  
  # Create a summary data frame with average median values for each room range
  summary_data <- aggregate(medv ~ rm_range, boston_data, mean)
  
  # Plot the bar chart
  ggplot(summary_data, aes(x = rm_range, y = medv)) +
    geom_bar(stat = "identity", fill = "blue") +
    labs(title = "Average Median Value of Homes by Room Range",
         x = "Room Range (Average Number of Rooms)",
         y = "Average Median Value (in $1000s)") +
    theme_minimal() +
    theme(axis.text.x = element_text(angle = 45, hjust = 1))

 # Split the data into training and testing sets
  set.seed(123)
  train_indices <- createDataPartition(boston$MEDIAN, p = 0.7, list = FALSE)
  train_data <- boston[train_indices, ]
  test_data <- boston[-train_indices, ]
  


shinyApp(ui = ui, server = server)




















