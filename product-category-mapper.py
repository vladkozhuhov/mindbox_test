from pyspark.sql import DataFrame
from pyspark.sql.functions import col


def get_product_category_pairs(products_df: DataFrame, categories_df: DataFrame, product_category_df: DataFrame) -> DataFrame:
    products_with_categories = products_df.join(
        product_category_df,
        products_df.id == product_category_df.product_id,
        "left"
    )
    
    result_df = products_with_categories.join(
        categories_df,
        products_with_categories.category_id == categories_df.id,
        "left"
    )
    
    final_result = result_df.select(
        products_df["name"].alias("product_name"),
        categories_df["name"].alias("category_name")
    )
    
    return final_result


# Пример
if __name__ == "__main__":
    from pyspark.sql import SparkSession
    
    spark = SparkSession.builder \
        .appName("Product Category Mapper") \
        .getOrCreate()
    
    # Простые тестовые данные
    products_data = [
        (1, "Телефон"),
        (2, "Ручка"),
        (3, "Тетрадь"),
        (4, "Стол"),
        (5, "Продукт без категории")
    ]
    
    categories_data = [
        (1, "Электроника"),
        (2, "Канцтовары"),
        (3, "Мебель")
    ]
    
    product_category_data = [
        (1, 1),  # телефон - электроника
        (2, 2),  # ручка - канцтовары
        (3, 2),  # тетрадь - канцтовары
        (4, 3)   # стол - мебель
    ]
    
    products_df = spark.createDataFrame(products_data, ["id", "name"])
    categories_df = spark.createDataFrame(categories_data, ["id", "name"])
    product_category_df = spark.createDataFrame(product_category_data, ["product_id", "category_id"])
    
    result = get_product_category_pairs(products_df, categories_df, product_category_df)
    
    print("Результат:")
    result.show(truncate=False)